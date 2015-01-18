﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34014
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SharpDomain.EventSourcing
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("EventSourced")]
    [NUnit.Framework.CategoryAttribute("framework")]
    [NUnit.Framework.CategoryAttribute("eventsourcing")]
    public partial class EventSourcedFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "EventSourced.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EventSourced", "Base class for event sourced entities", ProgrammingLanguage.CSharp, new string[] {
                        "framework",
                        "eventsourcing"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a new entity without applying or appending any event")]
        public virtual void CreateANewEntityWithoutApplyingOrAppendingAnyEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a new entity without applying or appending any event", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("A new entity is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "LastName",
                        "EntityId",
                        "CommittedVersion",
                        "AppendedVersion",
                        "AppendedEvents"});
            table1.AddRow(new string[] {
                        "<null>",
                        "<null>",
                        "00000000-0000-0000-0000-000000000000",
                        "0",
                        "0",
                        "0"});
#line 8
 testRunner.Then("The the following entity is obtained", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create an entity by applying an entity created event")]
        public virtual void CreateAnEntityByApplyingAnEntityCreatedEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create an entity by applying an entity created event", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
 testRunner.Given("A new entity is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table2.AddRow(new string[] {
                        "Name",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "1"});
#line 14
 testRunner.When("The following entity created event is applied", ((string)(null)), table2, "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "LastName",
                        "EntityId",
                        "CommittedVersion",
                        "AppendedVersion",
                        "AppendedEvents"});
            table3.AddRow(new string[] {
                        "Name",
                        "<null>",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "1",
                        "1",
                        "0"});
#line 17
 testRunner.Then("The the following entity is obtained", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create an entity by appending an entity created event")]
        public virtual void CreateAnEntityByAppendingAnEntityCreatedEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create an entity by appending an entity created event", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("A new entity is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table4.AddRow(new string[] {
                        "Name",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "1"});
#line 23
 testRunner.When("The following entity created event is appended", ((string)(null)), table4, "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "LastName",
                        "EntityId",
                        "CommittedVersion",
                        "AppendedVersion",
                        "AppendedEvents"});
            table5.AddRow(new string[] {
                        "Name",
                        "<null>",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "0",
                        "1",
                        "1"});
#line 26
 testRunner.Then("The the following entity is obtained", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appending a creation event to an already existing entity is considered an error")]
        public virtual void AppendingACreationEventToAnAlreadyExistingEntityIsConsideredAnError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appending a creation event to an already existing entity is considered an error", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
 testRunner.Given("A new entity is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table6.AddRow(new string[] {
                        "Name",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "1"});
#line 32
 testRunner.When("The following entity created event is applied", ((string)(null)), table6, "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table7.AddRow(new string[] {
                        "Name2",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "2"});
#line 35
 testRunner.And("The following entity created event is appended", ((string)(null)), table7, "And ");
#line 38
 testRunner.Then("an invalid operation exception is raised", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appending a non-creation event to a new entity is considered an error")]
        public virtual void AppendingANon_CreationEventToANewEntityIsConsideredAnError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appending a non-creation event to a new entity is considered an error", ((string[])(null)));
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
 testRunner.Given("A new entity is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table8.AddRow(new string[] {
                        "Name2",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "1"});
#line 42
 testRunner.When("The following entity first name updated event is appended", ((string)(null)), table8, "When ");
#line 45
 testRunner.Then("an invalid operation exception is raised", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appending an event to an already existing entity with non-corresponding entity id" +
            "s is considered an error")]
        public virtual void AppendingAnEventToAnAlreadyExistingEntityWithNon_CorrespondingEntityIdsIsConsideredAnError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appending an event to an already existing entity with non-corresponding entity id" +
                    "s is considered an error", ((string[])(null)));
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
 testRunner.Given("A new entity is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table9.AddRow(new string[] {
                        "Name",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "1"});
#line 49
 testRunner.When("The following entity created event is applied", ((string)(null)), table9, "When ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table10.AddRow(new string[] {
                        "Name2",
                        "6D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "2"});
#line 52
 testRunner.And("The following entity first name updated event is appended", ((string)(null)), table10, "And ");
#line 55
 testRunner.Then("an invalid operation exception is raised", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Applying an event to an already modified entity is considered an error")]
        public virtual void ApplyingAnEventToAnAlreadyModifiedEntityIsConsideredAnError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Applying an event to an already modified entity is considered an error", ((string[])(null)));
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
 testRunner.Given("A new entity is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table11.AddRow(new string[] {
                        "Name",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "1"});
#line 59
 testRunner.When("The following entity created event is appended", ((string)(null)), table11, "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table12.AddRow(new string[] {
                        "Name2",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "2"});
#line 62
 testRunner.And("The following entity first name updated event is applied", ((string)(null)), table12, "And ");
#line 65
 testRunner.Then("an invalid operation exception is raised", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Applying an event to an already existing entity with non-corresponding entity ids" +
            " is considered an error")]
        public virtual void ApplyingAnEventToAnAlreadyExistingEntityWithNon_CorrespondingEntityIdsIsConsideredAnError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Applying an event to an already existing entity with non-corresponding entity ids" +
                    " is considered an error", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
 testRunner.Given("A new entity is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table13.AddRow(new string[] {
                        "Name",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "1"});
#line 69
 testRunner.When("The following entity created event is applied", ((string)(null)), table13, "When ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table14.AddRow(new string[] {
                        "Name2",
                        "6D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "2"});
#line 72
 testRunner.And("The following entity first name updated event is applied", ((string)(null)), table14, "And ");
#line 75
 testRunner.Then("an invalid operation exception is raised", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Applying a created event to an already existing entity is considered an error")]
        public virtual void ApplyingACreatedEventToAnAlreadyExistingEntityIsConsideredAnError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Applying a created event to an already existing entity is considered an error", ((string[])(null)));
#line 77
this.ScenarioSetup(scenarioInfo);
#line 78
 testRunner.Given("A new entity is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table15.AddRow(new string[] {
                        "Name",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "1"});
#line 79
 testRunner.When("The following entity created event is applied", ((string)(null)), table15, "When ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table16.AddRow(new string[] {
                        "Name2",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "2"});
#line 82
 testRunner.And("The following entity created event is applied", ((string)(null)), table16, "And ");
#line 85
 testRunner.Then("an invalid operation exception is raised", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Applying a non-creation event to a new entity is considered an error")]
        public virtual void ApplyingANon_CreationEventToANewEntityIsConsideredAnError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Applying a non-creation event to a new entity is considered an error", ((string[])(null)));
#line 87
this.ScenarioSetup(scenarioInfo);
#line 88
 testRunner.Given("A new entity is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "EntityId",
                        "EventVersion"});
            table17.AddRow(new string[] {
                        "Name2",
                        "5D7C247E-CBF8-4F6C-BB9B-05F9DD45FB2F",
                        "1"});
#line 89
 testRunner.When("The following entity first name updated event is applied", ((string)(null)), table17, "When ");
#line 92
 testRunner.Then("an invalid operation exception is raised", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
