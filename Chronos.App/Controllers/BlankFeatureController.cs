using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.App.DataContracts;
using Microsoft.AspNetCore.Authorization;
using ApiContract = Chronos.App.DataContracts.Blank;

namespace Chronos.App.Controllers
{
    [Authorize]
    [Route("api/blank-features")]
    [ApiController]
    public class BlankFeatureController : Controller
    {
        public BlankFeatureController()
        {

        }

        [HttpGet("{id:int}")]
        public async Task<ApiResponse<ApiContract.BlankFeature>> GetAsync([FromRoute] int id)
        {
            var apiData = new ApiContract.BlankFeature
            {
                Name = "Some Feature",
                FeatureId = 2,
                Tasks = new List<ApiContract.BlankTask>
                {
                    new()
                    {
                        Activity = "Some FeatureTask Activity 1",
                        Name = "Some FeatureTask Name 1",
                        OriginalEstimate = 1,
                        Tags = new List<string> 
                        { 
                            "2021",
                            "CDB",
                            "CSI"
                        },
                        SuggestedTags = new List<string> 
                        { 
                            DateTime.Now.Year.ToString(),
                            "CDB",
                            "Some Team"
                        }
                    },
                    new()
                    {
                        Activity = "Some FeatureTask Activity 2",
                        Name = "Some FeatureTask Name 2",
                        OriginalEstimate = 2,
                        Tags = new List<string>
                        {
                            "2021",
                            "CDB",
                            "CSI"
                        },
                        SuggestedTags = new List<string>
                        {
                            DateTime.Now.Year.ToString(),
                            "CDB",
                            "Some Team"
                        }
                    },
                    new()
                    {
                        Activity = "Some FeatureTask Activity 3",
                        Name = "Some FeatureTask Name 3",
                        OriginalEstimate = 3,
                        Tags = new List<string>
                        {
                            "2021",
                            "CDB",
                            "CSI"
                        },
                        SuggestedTags = new List<string>
                        {
                            DateTime.Now.Year.ToString(),
                            "CDB",
                            "Some Team"
                        }
                    }
                },
                ZeroStory = new ApiContract.BlankStory
                {
                    StoryId = 1,
                    Name = "Some ZeroStory Name 1",
                    OrderNumber = 1,
                    Tasks = new List<ApiContract.BlankTask>
                    {
                        new()
                        {
                            TaskId = 1,
                            Activity = "Some ZeroTask Activity 1",
                            Name = "Some ZeroTask Name 1",
                            OriginalEstimate = 1
                        },
                        new()
                        {
                            TaskId = 2,
                            Activity = "Some ZeroTask Activity 2",
                            Name = "Some ZeroTask Name 2",
                            OriginalEstimate = 2
                        },
                        new()
                        {
                            TaskId = 3,
                            Activity = "Some ZeroTask Activity 3",
                            Name = "Some ZeroTask Name 3",
                            OriginalEstimate = 3
                        }
                    }
                },
                Stories = new List<ApiContract.BlankStory>
                {
                    new ()
                    {
                        StoryId = 2,
                        Name = "Some Story Name 1",
                        OrderNumber = 1,
                        Tasks = new List<ApiContract.BlankTask>
                        {
                            new()
                            {
                                TaskId = 4,
                                Activity = "Some Task Activity 1",
                                Name = "Some Task Name 1",
                                OriginalEstimate = 1
                            },
                            new()
                            {
                                TaskId = 5,
                                Activity = "Some Task Activity 2",
                                Name = "Some Task Name 2",
                                OriginalEstimate = 2
                            },
                            new()
                            {
                                TaskId = 6,
                                Activity = "Some Task Activity 3",
                                Name = "Some Task Name 3",
                                OriginalEstimate = 3
                            }
                        }
                    },
                    new ()
                    {
                        StoryId = 3,
                        Name = "Some Story Name 2",
                        OrderNumber = 1,
                        Tasks = new List<ApiContract.BlankTask>
                        {
                            new()
                            {
                                TaskId = 7,
                                Activity = "Some Task Activity 4",
                                Name = "Some Task Name 4",
                                OriginalEstimate = 4
                            },
                            new()
                            {
                                TaskId = 8,
                                Activity = "Some Task Activity 5",
                                Name = "Some Task Name 5",
                                OriginalEstimate = 5
                            },
                            new()
                            {
                                TaskId = 9,
                                Activity = "Some Task Activity 6",
                                Name = "Some Task Name 6",
                                OriginalEstimate = 6
                            },
                            new()
                            {
                                TaskId = 10,
                                Activity = "Some Task Activity 7",
                                Name = "Some Task Name 7",
                                OriginalEstimate = 256,
                                Tags = new List<string>
                                {
                                    "2021",
                                    "CDB",
                                    "CSI"
                                },
                                SuggestedTags = new List<string>
                                {
                                    DateTime.Now.Year.ToString(),
                                    "CDB",
                                    "Some Team"
                                }
                            }
                        }
                    }
                }
            };
            
            return new ApiResponse<ApiContract.BlankFeature>(apiData);
        }
    }
}
