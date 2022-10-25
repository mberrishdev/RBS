//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Calendar.v3;
//using Google.Apis.Calendar.v3.Data;
//using Google.Apis.Services;

//namespace RBS.Infrastructure
//{
//    public class Class1
//    {
//        public void Test()
//        {
//            CalendarService _service = this.GetCalendarService("rbsdev-e6d968f6edc9.json");
//            CreateEvent(_service);
//            GetEvents(_service);
//        }
//        private CalendarService GetCalendarService(string keyfilepath)
//        {
//            try
//            {
//                string[] Scopes = {
//                   CalendarService.Scope.Calendar,
//                   CalendarService.Scope.CalendarEvents,
//                   CalendarService.Scope.CalendarEventsReadonly
//                  };

//                GoogleCredential credential;
//                using (var stream = new FileStream(keyfilepath, FileMode.Open, FileAccess.Read))
//                {
//                    // As we are using admin SDK, we need to still impersonate user who has admin access    
//                    //  https://developers.google.com/admin-sdk/directory/v1/guides/delegation    
//                    credential = GoogleCredential.FromStream(stream)
//                     .CreateScoped(Scopes).CreateWithUser("spidey@avengers.com");
//                }

//                // Create Calendar API service.    
//                var service = new CalendarService(new BaseClientService.Initializer()
//                {
//                    HttpClientInitializer = credential,
//                    ApplicationName = "Calendar Sample",
//                });
//                return service;
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }
//        private void CreateEvent(CalendarService _service)
//        {
//            Event body = new Event();
//            EventAttendee a = new EventAttendee
//            {
//                Email = "mishiko.berishvili12@gmail.com"
//            };
//            List<EventAttendee> attendes = new List<EventAttendee>
//            {
//                a
//            };
//            body.Attendees = attendes;
//            EventDateTime start = new()
//            {
//                DateTime = Convert.ToDateTime("2019-08-28T09:00:00+0530")
//            };
//            EventDateTime end = new()
//            {
//                DateTime = Convert.ToDateTime("2019-08-28T11:00:00+0530")
//            };

//            body.Start = start;
//            body.End = end;
//            body.Location = "Avengers Mansion";
//            body.Summary = "Discussion about new Spidey suit";
//            EventsResource.InsertRequest request = new(_service, body, "nickfury@avengers.com");
//            Event response = request.Execute();
//        }

//        private void GetEvents(CalendarService _service)
//        {
//            // Define parameters of request.    
//            EventsResource.ListRequest request = _service.Events.List("primary");
//            request.TimeMin = DateTime.Now;
//            request.ShowDeleted = false;
//            request.SingleEvents = true;
//            request.MaxResults = 10;
//            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

//            string eventsValue = "";
//            // List events.    
//            Events events = request.Execute();
//            eventsValue = "Upcoming events:\n";
//            if (events.Items != null && events.Items.Count > 0)
//            {
//                foreach (var eventItem in events.Items)
//                {
//                    string when = eventItem.Start.DateTime.ToString();
//                    if (String.IsNullOrEmpty(when))
//                    {
//                        when = eventItem.Start.Date;
//                    }
//                    eventsValue += string.Format("{0} ({1})", eventItem.Summary, when) + "\n";
//                }
//                MessageBox.Show(eventsValue);
//            }
//            else
//            {
//                MessageBox.Show("No upcoming events found.");
//            }
//        }
//    }
//}
