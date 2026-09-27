using PatternsLab.Builder;
using PatternsLab.Prototype;
using PatternsLab.Singleton;
using System.Diagnostics;

Console.WriteLine("=== SINGLETON: AFTER ===\n");

var db = new DatabaseService();
var ui = new UiService();

db.Config.Theme = "Dark";
Console.WriteLine("Admin changed theme to Dark.");

ui.Render();

Console.WriteLine($"\nSame config object? {ReferenceEquals(db.Config, ui.Config)}");
Console.WriteLine($"Times config was loaded from disk: {AppConfig.LoadCount}");

Console.WriteLine("\n=== PROTOTYPE: AFTER ===\n");

var sw = Stopwatch.StartNew();

var army = new List<Enemy>();
Enemy prototype = new Orc();

for (int i = 1; i <= 5; i++)
{
    var orc = prototype.Clone();
    orc.Name = $"Orc-{i}";
    army.Add(orc);
}

Console.WriteLine($"Created 5 orcs in {sw.ElapsedMilliseconds} ms\n");

Enemy original = prototype;
original.Name = "Boss Orc";

Enemy copy = EnemyCopyHelper.CopyEnemy(original);

Console.WriteLine($"Original model id: {original.ModelId}");
Console.WriteLine($"Copy model id:     {copy.ModelId}");

copy.Weapon.Damage = 999;

Console.WriteLine("\nWe changed the COPY's weapon damage to 999.");
Console.WriteLine($"Original's weapon damage is now: {original.Weapon.Damage}");

copy.Abilities.Add("Fire Breath");

Console.WriteLine($"Original abilities: {string.Join(", ", original.Abilities)}");
Console.WriteLine();

Console.WriteLine("\n=== BUILDER: AFTER ===\n");
var liveStudent = new CourseRegistrationBuilder()
    .ForStudent("sara@mail.com")
    .ForCourse("SEF-101")
    .LiveGroup("G1")
    .WithDiscount("EARLY10")
    .SendWhatsApp()
    .SendEmailWelcome()
    .WithMentorNote("Needs evening slot")
    .WithPreferredStart(new DateOnly(2026, 10, 1))
    .Build();
Console.WriteLine(liveStudent);

var videosStudent = new CourseRegistrationBuilder()
    .ForStudent("ali@mail.com")
    .ForCourse("SEF-101")
    .VideosOnly()
    .SendEmailWelcome()
    .Build();

Console.WriteLine(videosStudent);