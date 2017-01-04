using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Diagnostics;

namespace UnitTestProject1
{
    [TestClass]
    public class EquipTests
    {
        public static string GetLogFor(object target)
        {
            var properties =
                from property in target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                select new
                {
                    Name = property.Name,
                    Value = property.GetValue(target, null)
                };

            var builder = new StringBuilder();

            foreach (var property in properties)
            {
                builder
                    .Append(property.Name)
                    .Append(" = ")
                    .Append(property.Value)
                    .AppendLine();
            }

            return builder.ToString();
        }

        [TestMethod]
        public void ManyWeapons()
        {
            List<Enemy> enemylist = new List<Enemy>();
            for (int i =0; i < 100; i++)
            {
                Enemy enemy = new Enemy(1);
                enemylist.Add(enemy);
            }
            var weapons =
                from enemy in enemylist
                where enemy.EquippedWeapon.ItemStats.Contains(BaseItem.Stats.ENHANCED_EFFECT)
                select enemy.EquippedWeapon;
            Debug.WriteLine(weapons.Count());
        }
    }
}
