# DummyAutomation

This project is meant to serve as a testing service for creating and posting users using the https://gorest.co.in/ public API. 

In order to run this you'll need the following : 

1 - Any IDE ( Preferably Vs Studio 2019 )  > Clone the solution to any repository you want;

2 - You will need to have the following extensions installed;

   * Specflow for Visual Studio 2019;
   
3 - Open the solution > Build the solution so the packages are installed;

4 - Make sure the following nuget extensions are not broken or unninstalled: 
   
   * Specflow,
   * Specflow.MsTest,
   * Specflow.Tools.MsBuild.Generation;
   
5 - After you have it all set up open TestExplorer window ( ALT+Q < Search for TestExplorer > );


## Bdd and code 

   * The bdd can be found in the .feature file (GoRestUserRegistry.feature);
   
   * The code is commented as much as possible for better understanding;
   