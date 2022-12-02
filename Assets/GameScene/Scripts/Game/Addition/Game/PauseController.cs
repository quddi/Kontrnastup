using System.Collections.Generic;
using UnityEngine;

public static class PauseController
{
    private static List<IPauseHandler> pauseHandlers = new List<IPauseHandler>();

    public static bool GamePaused { get; private set; } = false;

    public static void Register(IPauseHandler pauseHandler)
    {
        pauseHandlers.Add(pauseHandler);
    }

    public static void Unregister(IPauseHandler pauseHandler)
    {
        if (pauseHandlers.Contains(pauseHandler))
            pauseHandlers.Remove(pauseHandler);
    }

    public static void Pause()
    {
        foreach (var handler in pauseHandlers)
            handler.Pause();

        GamePaused = true;
    }

    public static void Unpause()
    {
        foreach (var handler in pauseHandlers)
            handler.Unpause();

        GamePaused = false;
    }
}
