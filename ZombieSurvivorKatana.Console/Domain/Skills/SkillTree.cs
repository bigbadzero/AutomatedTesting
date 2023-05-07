using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp.Domain.Skills
{
    public class SkillTree
    {
        public List<Skill> PotentialYellowSkills = new List<Skill>();
        public List<Skill> PotentialOrangeSkills = new List<Skill>();
        public List<Skill> PotentialRedSkills = new List<Skill>();

        public List<Skill> UnlockedSkills = new List<Skill>();

        public SkillTree()
        {
            LoadSkills();
        }

        private void LoadSkills()
        {
            var skills = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(Skill).IsAssignableFrom(type) && !type.IsInterface);
                
            foreach (var skill in skills)
            {
                var instance = (Skill)Activator.CreateInstance(skill);
                if(instance.Level == Level.Yellow)
                    PotentialYellowSkills.Add(instance);
                if (instance.Level == Level.Orange)
                    PotentialOrangeSkills.Add(instance);
                if (instance.Level == Level.Red)
                    PotentialRedSkills.Add(instance);
            }
        }

        public void SkillUp(int exp)
        {
            switch (exp)
            {
                case 7:
                    GainSkill(PotentialYellowSkills);
                    break;
                    //orange unlocks
                case 19:
                    GainSkill(PotentialOrangeSkills);
                    break;
                case 61:
                    GainSkill(PotentialOrangeSkills);
                    break;
                case 104:
                    GainSkill(PotentialOrangeSkills);
                    break;
                //red unlocks
                case 43:
                    GainSkill(PotentialRedSkills);
                    break;
                case 86:
                    GainSkill(PotentialRedSkills);
                    break;
                case 129:
                    GainSkill(PotentialRedSkills);
                    break;
            }
        }

        public void GainSkill(List<Skill> skillSource)
        {
            var count = skillSource.Count;
            var random = new Random();
            var index = random.Next(0, count);
            var skill = skillSource[index];
            skillSource.Remove(skill);
            UnlockedSkills.Add(skill);
        }

    }
}
