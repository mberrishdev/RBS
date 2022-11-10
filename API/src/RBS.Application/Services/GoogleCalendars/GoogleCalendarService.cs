using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using RBS.Application.Services.GoogleCalendars.RequestModel;

namespace RBS.Application.Services.GoogleCalendars
{
    public static class GoogleCalendarService
    {
        public async static Task<Event> CreateGoogleCalendar(GoogleCalendar request)
        {
            string[] Scopes = { "https://www.googleapis.com/auth/calendar" };
            string ApplicationName = "Google Canlendar Api";

            var clientSecrets = new ClientSecrets()
            {
                ClientId = "732593071024-bmd02mkmv1smbq0817olrv7618g2mmka.apps.googleusercontent.com",
                ClientSecret = "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"
            };

            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets,
                Scopes,
                "user",
                CancellationToken.None);

            // define services
            var services = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // define request
            Event eventCalendar = new()
            {
                Attendees = new List<EventAttendee>()
                {
                    new EventAttendee()
                    {
                        Email = "m_berishvili3@cu.edu.ge"
                    }
                },
                Summary = request.Summary,
                Location = request.Location,
                Start = new EventDateTime
                {
                    DateTime = request.Start,
                    TimeZone = "Asia/Ho_Chi_Minh"
                },
                End = new EventDateTime
                {
                    DateTime = request.End,
                    TimeZone = "Asia/Ho_Chi_Minh"
                },
                Description = request.Description
            };

            var eventRequest = services.Events.Insert(eventCalendar, "primary");
            var requestCreate = await eventRequest.ExecuteAsync();
            return requestCreate;
        }
    }
}
