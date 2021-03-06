using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgrammaticFiltering.Authorization;
using ProgrammaticFiltering.Data;
using ProgrammaticFiltering.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ProgrammaticFiltering.Pages
{
    public class Chart1Model : DI_BasePageModel
    {
        public string url;
        public string embedToken;

        public Chart1Model(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager,
            IProgrammaticFilteringService programmaticFilteringService)
            : base(context, authorizationService, userManager, programmaticFilteringService)
        {
        }

        public async Task OnGetAsync()
        {
            var username = UserManager.GetUserName(User);
            ProgrammaticFilter programmaticFilter = ProgrammaticFilteringService.getProgrammaticFilter(username);
            url = Constants.EmbedUrl + programmaticFilter.EmbedId;
            var domoHttpClient = new DomoHttpClient();

             var accessToken = await domoHttpClient.GetAccessTokenAsync(programmaticFilter.ClientId, programmaticFilter.ClientSecret);
            //var accessToken = "8906cd4427f10da4e37a5ad3a68f5515355a6e839215a15d";
            embedToken = await domoHttpClient.GetEmbedToken(accessToken, programmaticFilter.EmbedId, programmaticFilter.Filter);
        }
    }
}
