using HighlyDeveloped.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace HighlyDeveloped.Core.Controllers
{
    public class TwitterController : SurfaceController
    {
        public ActionResult GetTweets(string twitterHandle)
        {
            string PARTIAL_VIEW_FOLDER = "~/Views/Partials";

            // Create the view model and initialise it
            var viewModel = new TwitterViewModel();
            viewModel.TwitterHandle = twitterHandle;

            // Grab the tweet data from twitter API
            try
            {
                var tweets = GetLatestTweets(twitterHandle, 4);
                viewModel.Json = tweets;
                viewModel.Error = false;
            }
            catch (Exception ex)
            {

                viewModel.Error = true;
                viewModel.Message = ex.Message + ex.StackTrace;
            }

            // Return the view

            return PartialView(PARTIAL_VIEW_FOLDER + "/LatestTweets.cshtml", twitterHandle);
        }

        private string GetLatestTweets(string twitterHandle, int numberOfTweets)
        {
            throw new NotImplementedException();
        }
    }
}
