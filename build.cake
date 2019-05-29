#addin "nuget:?package=Cake.Docker"

var target = Argument("target", "Default");
var tag = Argument("tag", "cake");
var published = Directory("./published");
var configuration = Argument("Configuration", "Release");

Task("Restore").Does(() =>
{
    DotNetCoreRestore("PaymentGatewayService.sln");
});

Task("Build").IsDependentOn("Restore").Does(() =>
{
    DotNetCoreBuild("PaymentGatewayService.sln");
});

Task("Publish").Does(() => 
{
	if(!DirectoryExists(published))
	{
		CreateDirectory(published);
	}
	
	var setting = new DotNetCorePublishSettings
	{
		Configuration = configuration,
		Framework = "netcoreapp1.1",
		OutputDirectory = published
	};
	
	DotNetCorePublish("PaymentGatewayService.sln", setting);
});

Task("DockerCompose").IsDependentOn("Publish")
    .Does(() =>
{


    var settings = new DockerComposeUpSettings
    {
        Build = true,
        DetachedMode = true,
        Files = new[] { "docker-compose.yml" }
    };

    DockerComposeUp(settings);
});

Task("Default").IsDependentOn("DockerCompose");

RunTarget(target);