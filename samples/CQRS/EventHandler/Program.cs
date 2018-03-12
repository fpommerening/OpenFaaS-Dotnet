using System;
using System.Threading;
using Domain.Events;
using EventHandler.Projections;

namespace EventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            Messaging.EventBus myBus = null;
            IDisposable addConferenceSub = null;
            IDisposable newRegistrationSub = null;
            IDisposable cancelRegistrationSub = null;
            try
            {
                myBus = new Messaging.EventBus();
                addConferenceSub = myBus.Subscribe<AddConferenceEvent>("AddConference",
                    async x =>
                    {
                        await Conference.Handle(x);
                        await ConferenceList.Handle(x);
                    });
             
                newRegistrationSub = myBus.Subscribe<NewRegistrationEvent>("NewRegistration", async x =>
                {
                    await Conference.Handle(x);
                    await AttendeeList.Handle(x);
                });
              
                cancelRegistrationSub = myBus.Subscribe<CancelRegistrationEvent>("CancelRegistration", async x =>
                {
                    await Conference.Handle(x);
                    await AttendeeList.Handle(x);
                });

                while (Console.ReadLine() != "quit")
                {
                    Thread.Sleep(int.MaxValue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Event-Handler");
                Console.WriteLine(ex);
            }
            finally
            {
                addConferenceSub?.Dispose();
                newRegistrationSub?.Dispose();
                cancelRegistrationSub?.Dispose();

                myBus?.Dispose();
            }
        }
    }
}
