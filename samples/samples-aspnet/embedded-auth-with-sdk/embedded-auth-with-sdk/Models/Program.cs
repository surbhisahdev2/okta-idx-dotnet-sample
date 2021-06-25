using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace embedded_auth_with_sdk.Models
{
    public class Program
    {

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "PS Google Sheet";
        static readonly string SpreadsheetId = "1tgi-8YxVK4JMmj8C3mIpf0eimwUd2mKi06AWYeqnV-8";
        static readonly string sheet = "Sheet1";
        static SheetsService service;
      
        public void googleSheets()
        {
            GoogleCredential credential;

            string path1 = HttpContext.Current.Server.MapPath("..");

            string path2 = "\\Scripts\\credentials.json";
            using (var stream = new FileStream(path1+path2, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }
            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            //  ReadEntries();
            //CreateEntry();
            //UpdateEntry();

        }
        public List<ProjectStartViewModel> ReadEntries()
        {
            var range = $"{sheet}!A:F";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            IList<IList<object>> values = response.Values;
            List<ProjectStartViewModel> listView = new List<ProjectStartViewModel>();

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    // Print columns A to F, which correspond to indices 0 and 4.
                    ProjectStartViewModel p = new ProjectStartViewModel();
                    p.User = row[0].ToString();
                    p.ProjectName = row[1].ToString();
                    p.Implementation = row[2].ToString();
                    p.UseCase = row[3].ToString();

                    listView.Add(p);
                 //   Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5}", row[0], row[1], row[2], row[3], row[4], row[5]);
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
            return listView;
        }
        public void CreateEntry(string ProjectName, string Implementation, string UseCase, string User)
        {
            googleSheets();
            
            var range = $"{sheet}!A:F";
            var valueRange = new ValueRange();
            
            var oblist = new List<object>() { ProjectName, Implementation, UseCase, User};
            valueRange.Values = new List<IList<object>> { oblist };

            var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = appendRequest.Execute();
        }

        static void UpdateEntry()
        {
            var range = $"{sheet}!D2";
            var valueRange = new ValueRange();

            var oblist = new List<object>() { "updated" };
            valueRange.Values = new List<IList<object>> { oblist };

            var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = updateRequest.Execute();
        }
    }
    }