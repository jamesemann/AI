﻿namespace Microsoft.Bot.Solutions.Skills
{
    using System.Collections.Generic;
    using System.Linq;

    public class SkillRouter
    {
        private List<SkillService> _registeredSkills;

        public SkillRouter(List<SkillService> registeredSkills)
        {
            // Retrieve any Skills that have been registered with the Bot
            _registeredSkills = registeredSkills;
        }

        public SkillService IdentifyRegisteredSkill(string skillName)
        {
            SkillService matchedSkill = null;

            // Did we find any skills?
            if (_registeredSkills != null)
            {
                // Identify a skill by taking the LUIS model name identified by the dispatcher and matching to the skill luis model name
                // Bug raised on dispatcher to move towards LuisModelId instead perhaps?
                matchedSkill = _registeredSkills.FirstOrDefault(s => s.DispatchIntent == skillName);
                return matchedSkill;
            }
            else
            {
                return null;
            }
        }
    }
}
