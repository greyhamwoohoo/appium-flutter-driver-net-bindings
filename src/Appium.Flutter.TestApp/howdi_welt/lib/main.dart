import 'package:flutter_driver/driver_extension.dart';
import 'package:flutter/material.dart';

void main() {
  enableFlutterDriverExtension();
  
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
        visualDensity: VisualDensity.adaptivePlatformDensity,
      ),
      home: MyHomePage(title: 'appium-flutter-driver .Net Test App'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  MyHomePage({Key key, this.title}) : super(key: key);

  final String title;

  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  int _counter = 0;

  void _resetCounter() {
    setState(() {
      _counter=0;
    });
  }      

  void _changeCount(int amount) {
    setState(() {
      _counter += amount;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            OutlineButton(
              onPressed: _resetCounter,
              child: Text("Reset Counter",
              ),
            ),                   
            FlatButton(
              onPressed: () {
                _changeCount(-4);
              },
              child: Text("Flat Button Type - 4",
              ),
            ),            
            Text(
              'The counter is:',
            ),
            Text(
              '$_counter',
              key: ValueKey("counter"),
              style: Theme.of(context).textTheme.headline4,
            ),
            // Recommendation by flutter.dev is to use, at most, one FloatingActionButton per screen. Lets smash the system :)
            FloatingActionButton.extended(
              onPressed: () {
                _changeCount(1);
              },
              label: Text("Increment 1"),
              icon: Icon(Icons.add)
            ),            
            FloatingActionButton.extended(
              onPressed: () {
                _changeCount(2);
              },
              key: ValueKey("Up By Two"),
              label: Text("Up-By-Two"),
              icon: Icon(Icons.add)
            ),
            FloatingActionButton.extended(
              onPressed: () {
                _changeCount(3);
              },
              label: Text("Up-By-Three"),
              tooltip: "Raise Me By 3",
              icon: Icon(Icons.add)
            ),            
            Semantics (
              child: FloatingActionButton.extended(
              onPressed: () {
                _changeCount(4);
              },
                label: Text("Up-By-Four"),
                icon: Icon(Icons.add)
              ),
              label: "A Semantic Label To Raise By 4",
            ),
          ],
        ),
      ),
    );
  }
}
