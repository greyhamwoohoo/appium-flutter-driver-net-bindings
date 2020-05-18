# appium-flutter-driver-net-bindings
.Net Bindings for https://github.com/truongsinh/appium-flutter-driver

# STATUS: VERY MUCH A WORK IN PROGRESS!
This is a spike/poc for my needs at the moment; the 'appium-flutter-driver' that these .Net bindings rely on is (in the above authors words!) an experimental 'pre-0.1.x version'. Expect breaking changes. 

This is currently in 'Bootstrapping' mode: finders are in place, a few key session methods and a few commands. 

Android is the focus for now. 

## Version Compatibility Check
This is very much a work in progress against Appium v1.17.1 and appium-flutter-driver@0.0.23. 

To check your versions, do:

```
npm ls -g appium-flutter-driver
```

You will want to see something like this:

```
-- appium@1.17.1
  -- appium-flutter-driver@0.0.23
```

## Progress
I will use the same progress structure as 'appium-flutter-driver' to help track parity. 

### Finders
| Flutter Driver API | Status | Unit Tests | System Tests |
| ------------------ | ------ | ---------- | ------------ |
| ancestor           |   :x:  | :x:        | :x:          |
| bySemanticsLabel   |   :x:  | :x:        | :x:          |
| byTooltip          |   :x:  | :ok:       | :x:          |
| byType             |   :x:  | :ok:       | :x:          |
| byValueKey         |   :x:  | :ok:       | :x:          |
| descendent         |   :x:  | :x:        | :x:          |
| pageBack           |   :x:  | :ok:       | :x:          |
| text               |   :x:  | :ok:       | :x:          |

### Commands
TODO: Add the rest of these here

| Flutter API               | System Tests | WebDriver Example                                 | Scope   | 
| ------------------------- | ------------ | ------------------------------------------------- | ------- |
| FlutterDriver.connectedTo |   :ok:       | var addressOfRemoteServer = new Uri("http://127.0.0.1:4723/wd/hub");<br>var commandExecutor = new HttpCommandExecutor(addressOfRemoteServer, TimeSpan.FromSeconds(60));<br>var webDriver = new AndroidDriver<IWebElement>(commandExecutor, capabilities);<br>var fd = new FlutterDriver(webDriver, commandExecutor) | Session |
| checkHealth               |   :ok:       | theDriver.CheckHealth()                           | Session |
| clearTextbox              |   :x:        | TODO:                                             | Session |
| clearTimeline             |   :ok:       | theDriver.ClearTimeline()                         | Session |
| close                     |   :x:        | TODO:                                             | Session |
| enterText                 |   :x:        | TODO:                                             | Session |
| forceGC                   |   :ok:       | theDriver.ForceGC()                               | Session |
| getBottomLeft             |   :x:        | TODO:                                             | Widget  |
| getBottomRight            |   :x:        | TODO:                                             | Widget  |
| getCenter                 |   :x:        | TODO:                                             | Widget  |
| getRenderObjectDiagnostics|   :x:        | TODO:                                             | Widget  |
| getRenderTree             |   :ok:       | theDriver.GetRenderTree()                         | Session |
| getSemanticsId            |   :x:        | TODO:                                             | Widget  |
| getText                   |   :ok:       | theDriver.GetElementText(counterTextFinder)       | Widget  |
| getTopLeft                |   :x:        | TODO:                                             | Widget  |
| getTopRight               |   :x:        | TODO:                                             | Widget  |
| getVmFlags                |   :x:        | TODO:                                             | Session |
| getWidgetDiagnostics      |   :x:        | TODO:                                             | Widget  |
| requestData               |   :x:        | TODO:                                             | Session |
| runUnsyncrhonized         |   :x:        | TODO:                                             | Session |
| screenshot                |   :x:        | TODO:                                             | Session |
| screenshot                |   :x:        | TODO:                                             | Session |
| scroll                    |   :x:        | TODO:                                             | Widget  |
| scrollIntoView            |   :x:        | TODO:                                             | Widget  |
| scrollUntilVisible        |   :x:        | TODO:                                             | Widget  |
| setSemantics              |   :x:        | TODO:                                             | Session |
| setTextEntryEmulation     |   :x:        | TODO:                                             | Session |
| startTracing              |   :x:        | TODO:                                             | Session |
| stopTracingAndDownloadTimeline|   :x:    | TODO:                                             | Session |
| tap                       |   :x:        | TODO:                                             | Widget  |
| tap                       |   :x:        | TODO:                                             | Widget  |
| traceAction               |   :x:        | TODO:                                             | Session |
| waitFor                   |   :x:        | TODO:                                             | Widget  |
| waitForAbsent             |   :x:        | TODO:                                             | Widget  |
| waitUntilNoTransientCallbacks|   :x:     | TODO:                                             | Widget  |
| :question:                |   :x:        | setContext                                        | Appium  |
| :question:                |   :warning:  | getCurrentText                                    | Appium  |
| :question:                |   :warning:  | getContexts                                       | Appium  |
| :question:                |   :x:        | longTap                                           | Widget  |

## Stream of Conciousness
| Musing | Mumblings |
| ------ | --------- |
| Decorate or Isolate | I have chosen to design the solution (at present) by making  the .Net IFlutterDriver expose only the commands, methods and properties that Flutter Driver supports. <br><br>I am not using inheritance, deriving from or decorating any Selenium or Appium classes with extension methods unless I have to<br><br>Rationale: As there will likely be changes to 'appium-flutter-driver' and as there are many changes between the .Net Selenium 3 and 4 code bases, this approach seems the most resilient choice for consumers right now. <br><br>Providing the tests stick to consuming IFlutterDriver, the part most likely to change in future is the FlutterDriver construction. |
| FlutterBy.XXX times out if an element is not found | When doing something like FlutterDriver.GetElementText(FlutterBy.ValueKey("whatever")), if the element cannot be found I am getting a Timeout (as an exception; the Appium logs are silent on the not found) |

## References
| Reference | Link |
| --------- | ---- |
| Appium Flutter Driver | https://github.com/truongsinh/appium-flutter-driver | 
| Appium Flutter Driver Test App | https://github.com/truongsinh/appium-flutter-driver/releases/download/v0.0.4/android-real-debug.apk |
