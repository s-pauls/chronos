using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Data;
using Chronos.Domain.Entities.FeatureRules;
using Chronos.Domain.Interfaces;

namespace Chronos.Core
{
    public class FeatureRulesService : IFeatureRulesService
    {
        private readonly IFeatureRulesRepository _featureRulesRepository;

        public FeatureRulesService(
            IFeatureRulesRepository featureRulesRepository)
        {
            _featureRulesRepository = featureRulesRepository;
        }

        public async Task<List<FeatureRules>> GetListAsync()
        {
            return await _featureRulesRepository.GetListAsync();
        }

        public async Task<FeatureRules> GetByIdAsync(int id)
        {
            var defaultRules = GetDefaultItem();
            var featureRules = await _featureRulesRepository.GetByIdAsync(id);

            featureRules.FeatureTaskRules.TitleVariables = defaultRules.FeatureTaskRules.TitleVariables;
            featureRules.FeatureTaskRules.DefaultTags = CalculateDefaultTags(defaultRules.FeatureTaskRules.DefaultTags, featureRules.FeatureTaskRules.Tags);

            featureRules.ZeroStoryRules.TitleVariables = defaultRules.ZeroStoryRules.TitleVariables;
            featureRules.ZeroStoryRules.DefaultTags = CalculateDefaultTags(defaultRules.ZeroStoryRules.DefaultTags, featureRules.ZeroStoryRules.Tags);

            featureRules.ZeroTaskRules.TitleVariables = defaultRules.ZeroTaskRules.TitleVariables;
            featureRules.ZeroTaskRules.DefaultTags = CalculateDefaultTags(defaultRules.ZeroTaskRules.DefaultTags, featureRules.ZeroTaskRules.Tags);

            featureRules.StoryRules.TitleVariables = defaultRules.StoryRules.TitleVariables;
            featureRules.StoryRules.DefaultTags = CalculateDefaultTags(defaultRules.StoryRules.DefaultTags, featureRules.StoryRules.Tags);

            featureRules.TaskRules.TitleVariables = defaultRules.TaskRules.TitleVariables;
            featureRules.TaskRules.DefaultTags = CalculateDefaultTags(defaultRules.TaskRules.DefaultTags, featureRules.TaskRules.Tags);

            return featureRules;
        }

        private string[] CalculateDefaultTags(string[] defaultTags, string[] savedTags)
        {
            if (defaultTags == null)
            {
                return null;
            }

            if (savedTags == null)
            {
                return null;
            }

            return defaultTags.Except(savedTags).ToArray();
        }

        public FeatureRules GetDefaultItem()
        {
            return new FeatureRules
            {
                FeatureTaskRules = new TaskRules
                {
                    Title = FeatureRulesConstants.TitleVariables.TaskName,
                    TitleVariables = new[]
                    {
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.FeatureCode,
                            Description = Labels.FeatureRulesConstants_TitleVariables_FeatureCode_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.ProductCode,
                            Description = Labels.FeatureRulesConstants_TitleVariables_ProductCode_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.TaskName,
                            Description = Labels.FeatureRulesConstants_TitleVariables_TaskName_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.TaskOrderNumber,
                            Description = Labels.FeatureRulesConstants_TitleVariables_TaskOrderNumber_Description
                        },
                    },
                    DefaultTags = GetDefaultTags()
                },

                ZeroStoryRules = new StoryRules
                {
                    Title = $"{FeatureRulesConstants.TitleVariables.FeatureCode} - {FeatureRulesConstants.TitleVariables.ProductCode}: {FeatureRulesConstants.TitleVariables.StoryName}",
                    TitleVariables = new[]
                    {
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.FeatureCode,
                            Description = Labels.FeatureRulesConstants_TitleVariables_FeatureCode_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.ProductCode,
                            Description = Labels.FeatureRulesConstants_TitleVariables_ProductCode_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.StoryName,
                            Description = Labels.FeatureRulesConstants_TitleVariables_ZeroStoryName_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.StoryOrderNumber,
                            Description = Labels.FeatureRulesConstants_TitleVariables_ZeroStoryOrderNumber_Description
                        },
                    },
                    Tags = GetStoryTags()
                },

                ZeroTaskRules = new TaskRules
                {
                    Title = FeatureRulesConstants.TitleVariables.TaskName,
                    TitleVariables = new[]
                    {
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.FeatureCode,
                            Description = Labels.FeatureRulesConstants_TitleVariables_FeatureCode_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.ProductCode,
                            Description = Labels.FeatureRulesConstants_TitleVariables_ProductCode_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.StoryId,
                            Description = Labels.FeatureRulesConstants_TitleVariables_StoryId_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.StoryOrderNumber,
                            Description = Labels.FeatureRulesConstants_TitleVariables_ZeroStoryOrderNumber_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.TaskName,
                            Description = Labels.FeatureRulesConstants_TitleVariables_TaskName_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.TaskOrderNumber,
                            Description = Labels.FeatureRulesConstants_TitleVariables_TaskOrderNumber_Description
                        },
                    },
                    DefaultTags = GetDefaultTags()
                },

                StoryRules = new StoryRules
                {
                    Title = $"{FeatureRulesConstants.TitleVariables.FeatureCode} - {FeatureRulesConstants.TitleVariables.ProductCode}: {FeatureRulesConstants.TitleVariables.StoryName}",
                    TitleVariables = new[]
                    {
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.FeatureCode,
                            Description = Labels.FeatureRulesConstants_TitleVariables_FeatureCode_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.ProductCode,
                            Description = Labels.FeatureRulesConstants_TitleVariables_ProductCode_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.StoryName,
                            Description = Labels.FeatureRulesConstants_TitleVariables_StoryName_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.StoryOrderNumber,
                            Description = Labels.FeatureRulesConstants_TitleVariables_StoryOrderNumber_Description
                        },
                    },
                    Tags = GetStoryTags(),
                    Description = Labels.FeatureRulesConstants_TitleVariables_StoryDescription,
                    AcceptanceCriteria = Labels.FeatureRulesConstants_TitleVariables_StoryAcceptanceCriteria
                },

                TaskRules = new TaskRules
                {
                    Title = FeatureRulesConstants.TitleVariables.TaskName,
                    TitleVariables = new[]
                    {
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.FeatureCode,
                            Description = Labels.FeatureRulesConstants_TitleVariables_FeatureCode_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.ProductCode,
                            Description = Labels.FeatureRulesConstants_TitleVariables_ProductCode_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.StoryId,
                            Description = Labels.FeatureRulesConstants_TitleVariables_StoryId_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.StoryOrderNumber,
                            Description = Labels.FeatureRulesConstants_TitleVariables_ZeroStoryOrderNumber_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.TaskName,
                            Description = Labels.FeatureRulesConstants_TitleVariables_TaskName_Description
                        },
                        new TitleVariable
                        {
                            Code = FeatureRulesConstants.TitleVariables.TaskOrderNumber,
                            Description = Labels.FeatureRulesConstants_TitleVariables_TaskOrderNumber_Description
                        }
                    },
                    DefaultTags = GetDefaultTags()
                }
            };

            string[] GetStoryTags()
            {
                return new[]
                {
                    FeatureRulesConstants.TagVariables.Year,
                    FeatureRulesConstants.TagVariables.Product,
                    FeatureRulesConstants.TagVariables.Team
                };
            }

            string[] GetDefaultTags()
            {
                return new[]
                {
                    FeatureRulesConstants.TagVariables.Year,
                    FeatureRulesConstants.TagVariables.Product,
                    FeatureRulesConstants.TagVariables.Team
                };
            }

        }

        public async Task<int> AddAsync(FeatureRules featureRules)
        {
            CheckFeatureRules(featureRules);
            return await _featureRulesRepository.AddAsync(featureRules);
        }

        public async Task ModifyAsync(FeatureRules featureRules)
        {
            CheckFeatureRules(featureRules);
            await _featureRulesRepository.ModifyAsync(featureRules);
        }

        public async Task RemoveAsync(int id)
        {
            await _featureRulesRepository.RemoveAsync(id);
        }

        private void CheckFeatureRules(FeatureRules featureRules)
        {
            // todo add checks
        }

    }
}
