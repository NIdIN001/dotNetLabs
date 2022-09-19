using dotNetLab2.lab2.ru.nsu.brideApplication.configuration;
using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using dotNetLab2.lab2.ru.nsu.brideApplication.model.strategy;
using dotNetLab2.lab2.ru.nsu.brideApplication.service;
using Microsoft.Extensions.Configuration;

namespace dotNetLab2.lab2.ru.nsu.brideApplication;

public class Application
{
    public static void Main(string[] args)
    {
        ConfigurationManager configurationManager = new();
        configurationManager.AddJsonFile(
            "/Users/stanislavutockin/Documents/dotNetLabs/dotNetLab2/lab2/ru.nsu.brideApplication/appsettings.json");

        var reportConfiguration = new ReportConfiguration(configurationManager);
        var contenderConfiguration = new ContenderConfiguration(configurationManager);

        File.Delete(reportConfiguration.ReportPath);

        var totalHappiness = 0;
        for (int i = 0; i < contenderConfiguration.TriesCount; i++)
        {
            var reportService = new ReportService(reportConfiguration);
            var contenderGenerator =
                new ContenderGeneratorService(contenderConfiguration.ContendersCount,
                    contenderConfiguration.Firstname,
                    contenderConfiguration.Lastname);
            var hall = new Hall(contenderGenerator, contenderConfiguration);
            var friend = new Friend();

            IVoteStrategy voteStrategy = new WikiVoteStrategy(contenderConfiguration.ContendersCount, friend);
            
            var throneRoom = new ThroneRoom();
            var princess = new Princess(friend, voteStrategy);

            var princessChoice = throneRoom.ChooseHusband(princess, hall);

            var princessHappiness = Princess.GetHappiness(princessChoice, hall.GetAllContenders());
            totalHappiness += princessHappiness;

            reportService.WriteResultInReport(princessChoice, princessHappiness);
        }

        Console.Write(totalHappiness / (float)contenderConfiguration.TriesCount);
    }
}