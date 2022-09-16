using dotNetLabs.lab1.ru.nsu.brideApplication.configuration;
using dotNetLabs.lab1.ru.nsu.brideApplication.model;
using dotNetLabs.lab1.ru.nsu.brideApplication.model.strategy;
using dotNetLabs.lab1.ru.nsu.brideApplication.service;
using Microsoft.Extensions.Configuration;

namespace dotNetLabs.lab1.ru.nsu.brideApplication;

public class Application
{
    public static void Main(string[] args)
    {
        ConfigurationManager configurationManager = new();
        configurationManager.AddJsonFile("/Users/stanislavutockin/Documents/dotNetLabs/lab1/appsettings.json");

        var reportConfiguration = new ReportConfiguration(configurationManager);
        var contenderConfiguration = new ContenderConfiguration(configurationManager);

        File.Delete(reportConfiguration.ReportPath);

        var totalHappiness = 0;
        for (int i = 0; i < contenderConfiguration.TriesCount; i++)
        {
            var reportService = new ReportService(reportConfiguration);
            var contenderGenerator =
                new ContenderGeneratorService(contenderConfiguration.ContendersCount);
            var hall = new Hall(contenderGenerator, contenderConfiguration);

            IVoteStrategy voteStrategy = new WikiVoteStrategy(contenderConfiguration.ContendersCount);
            var friend = new Friend();
            var throneRoom = new ThroneRoom();
            var princess = new Princess(friend, voteStrategy);

            var princessChoice = throneRoom.ChooseHusband(princess, hall);

            int princessHappiness = Princess.GetHappiness(princessChoice, hall.GetAllContenders());
            totalHappiness += princessHappiness;

            reportService.WriteResultInReport(princessChoice, princessHappiness);
        }

        Console.Write(totalHappiness / (float)contenderConfiguration.TriesCount);
    }
}