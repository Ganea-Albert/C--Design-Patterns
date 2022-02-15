﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {

            Chatroom chatroom = new Chatroom();

            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new NonBeatle("Yoko");

            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);

            Yoko.Send("John", "Hi John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");

            Console.ReadKey();
        }
    }

    public abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);
        public abstract void Send(string from, string to, string message);
    }

    public class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Participant> participants = new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if(!participants.ContainsValue(participant))
            {
                participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override void Send(string from, string to, string message)
        {
            Participant participant = participants[to];

            if(participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }

    public class Participant
    {
        Chatroom chatroom;
        string name;

        public Participant(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public Chatroom Chatroom
        {
            set { chatroom = value; }
            get { return chatroom; }
        }

        public void Send(string to, string message)
        {
            chatroom.Send(name, to, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from, Name, message);
        }
    }

    public class Beatle : Participant
    {
        public Beatle(string name) : base(name) { }

        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }

    public class NonBeatle : Participant
    {
        public NonBeatle(string name)
            : base(name) { }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}
