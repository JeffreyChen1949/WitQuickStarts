using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WitQuickStarts.Samples
{
    public class QueryRecycleBin
    {
        readonly string _uri;
        readonly string _personalAccessToken;
        readonly string _project;

        public QueryRecycleBin()
        {
            _uri = "https://accountname.visualstudio.com";
            _personalAccessToken = "personal access token";
            _project = "project name";
            //_uri = "http://server201601/DefaultCollection/";
            //_personalAccessToken = "22or2hyfoclm4oupvfwnjceeurag5czu5xxhjhryy44ft4qtd27a";
            //_project = "ProjectGitAgile1";
        }

        /// <summary>
        /// Constructor. Manaully set values to match your account.
        /// </summary>
        public QueryRecycleBin(string url, string pat, string project)
        {
            _uri = url;
            _personalAccessToken = pat;
            _project = project;
        }

        /// <summary>
        /// Create a bug using the .NET client library
        /// </summary>
        /// <returns>Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem</returns>    
        public WorkItem QueryRecycleBinUsingClientLib()
        {
            try
            {
                Uri uri = new Uri(_uri);
            string personalAccessToken = _personalAccessToken;
            string project = _project;

            VssBasicCredential credentials = new VssBasicCredential(@"sqlrepro\administrator", "Password1");
            VssConnection connection = new VssConnection(uri, credentials);
            WorkItemTrackingHttpClient workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();

            
                var result = workItemTrackingHttpClient.GetDeletedWorkItemsAsync(project, null).Result;
                Console.WriteLine("RecycleBin work items are Successfully finded: response type #{0}", result.GetType());
                return null;
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Error creating bug: {0}", ex.InnerException.Message);
                return null;
            }
        }

    }
}