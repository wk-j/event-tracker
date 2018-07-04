#addin "wk.StartProcess"

using PS = StartProcess.Processor;

Task("Watch").Does(() => {
    PS.StartProcess("dotnet watch --project src/EventTracker run");
});

var target = Argument("target", "Watch");
RunTarget(target);