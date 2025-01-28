using System;
using T3PR1Practica1;
using Xunit;

public class EnergySystemTests
{
    [Fact]
    public void SolarSystem_CalculatesEnergyCorrectly()
    {
        // Arrange
        var solarSystem = new SolarSystem();
        double sunHours = 5;

        // Act
        solarSystem.ConfigureParameters(sunHours);
        double energy = solarSystem.CalculateEnergy();

        // Assert
        Assert.Equal(7.5, energy, 1);
    }

    [Fact]
    public void WindSystem_CalculatesEnergyCorrectly()
    {
        // Arrange
        var windSystem = new WindSystem();
        double windSpeed = 10;

        // Act
        windSystem.ConfigureParameters(windSpeed);
        double energy = windSystem.CalculateEnergy();

        // Assert
        Assert.Equal(200, energy, 1);
    }

    [Fact]
    public void HydroSystem_CalculatesEnergyCorrectly()
    {
        // Arrange
        var hydroSystem = new HydroelectricSystem();
        double waterFlow = 25;

        // Act
        hydroSystem.ConfigureParameters(waterFlow);
        double energy = hydroSystem.CalculateEnergy();

        // Assert
        Assert.Equal(196, energy, 1);
    }

    [Fact]
    public void SimulationDate_IsSetCorrectly()
    {
        // Arrange
        var solarSystem = new SolarSystem();
        solarSystem.SimulationDate = DateTime.Now;

        // Act
        var simulationDate = solarSystem.SimulationDate;

        // Assert
        Assert.True(simulationDate <= DateTime.Now);
        Assert.True(simulationDate > DateTime.Now.AddSeconds(-5)); // Assuming test runs within 5 seconds
    }
    [Fact]
    public void SolarSystem_CalculatesEnergyIncorrectly()
    {
        // Arrange
        var solarSystem = new SolarSystem();
        double sunHours = 8;

        // Act
        solarSystem.ConfigureParameters(sunHours);
        double energy = solarSystem.CalculateEnergy();

        // Assert
        Assert.NotEqual(7.5, energy, 1);
    }

    [Fact]
    public void WindSystem_CalculatesEnergyIncorrectly()
    {
        // Arrange
        var windSystem = new WindSystem();
        double windSpeed = 20;

        // Act
        windSystem.ConfigureParameters(windSpeed);
        double energy = windSystem.CalculateEnergy();

        // Assert
        Assert.NotEqual(200, energy, 1);
    }

    [Fact]
    public void HydroSystem_CalculatesEnergyIncorrectly()
    {
        // Arrange
        var hydroSystem = new HydroelectricSystem();
        double waterFlow = 205;

        // Act
        hydroSystem.ConfigureParameters(waterFlow);
        double energy = hydroSystem.CalculateEnergy();

        // Assert
        Assert.NotEqual(196, energy, 1);
    }

    [Fact]
    public void SimulationDate_IsSetIncorrectly()
    {
        // Arrange
        var solarSystem = new SolarSystem();
        solarSystem.SimulationDate = DateTime.Now;

        // Act
        var simulationDate = solarSystem.SimulationDate;

        // Assert
        Assert.False(simulationDate >= DateTime.Now);
        Assert.False(simulationDate < DateTime.Now.AddSeconds(-5)); // Assuming test runs within 5 seconds
    }
}
