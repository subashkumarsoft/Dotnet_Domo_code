using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammaticFiltering.Models;

namespace ProgrammaticFiltering
{
    public class ProgrammaticFilteringService : IProgrammaticFilteringService
    {
        private Dictionary<string, ProgrammaticFilter> filters = new Dictionary<string, ProgrammaticFilter>();

        public ProgrammaticFilteringService() {
            filters.Add("subash@test.com",
                new ProgrammaticFilter
                    {
                   ClientId = "f7d953c9-c05c-4075-85aa-0ec46afb1b91",  //css client id
                    ClientSecret = "0f80bd4fc3020afefd705d3309fb1b52428e729abf8de6e4a90ed75575e1d156", //css client secret

                    // ClientId = "b688696b-d1b7-4c8a-ac1c-edfe28c47b82",   //domo client id
                    //  ClientSecret = "ca482393bc9ec138d80c9daca01a56ad65e298252230a8b0a17e1c45fc278c77",  //domo client secret
                    Filter = "[]",
                    //Filter = "[{'column': 'Region', 'operator': 'IN', 'values': ['West']}]",

                    //EmbedId = "0RAxG"   //domo EmbedId
                    EmbedId = "qxm8p",   //css EmbedId
                 //   EMBED_TYPE = "dashboard"
                });
            filters.Add("susan@test.com",
                    new ProgrammaticFilter
                    {
                        ClientId = "CLIENT_ID",
                        ClientSecret = "CLIENT_SECRET",
                        Filter = "[]",
                        EmbedId = "EMBED_ID",
                    });
            filters.Add("tom@test.com",
                    new ProgrammaticFilter
                    {
                        ClientId = "CLIENT_ID",
                        ClientSecret = "CLIENT_SECRET",
                        Filter = "[]",
                        EmbedId = "EMBED_ID"
                    });
        }

        public ProgrammaticFilter getProgrammaticFilter(string username)
        {
            if (!filters.TryGetValue(username, out ProgrammaticFilter filter))
            {
                return new ProgrammaticFilter();
            }
            return filters[username];
        }
    }
}