using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using YamlDotNet;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Linq;
using System.Collections.Generic;

namespace Pec
{
    public class Tests
    {
        private System.Collections.Generic.List<User> users1 = new();
        private System.Collections.Generic.List<User> users2 = new();

        [SetUp]
        public void Setup()
        {
            var fileName1 = @"D:\программирование\пес\Pec\Pec\L1. Test users files\regular_users.json";
            var fileName2 = @"D:\программирование\пес\Pec\Pec\L1. Test users files\regular_users.yaml";

            var s1 = File.ReadAllText(fileName1);
            var s2 = File.ReadAllText(fileName2);

            users1 = JsonConvert.DeserializeObject<System.Collections.Generic.List<User>>(s1);

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();
            users2 = deserializer.Deserialize<System.Collections.Generic.List<User>>(s2);
        }

        [Test]
        public void Users1Valid()
        {
            Assert.IsTrue(users1.All(IsValidUser));
            Assert.IsTrue(users2.All(IsValidUser));
        }
        private bool IsValidUser(User u)
        {
            return u.Id != null && u.Name != null;
        }

        [Test]
        public void IsMatch()
        {
            var set1 = users1.ToHashSet(new UserComparer());
            var set2 = users2.ToHashSet(new UserComparer());


            Assert.IsTrue(set1.IsSubsetOf(set2));
        }
    }
}