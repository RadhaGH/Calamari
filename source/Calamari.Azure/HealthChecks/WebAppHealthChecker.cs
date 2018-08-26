﻿using System;
using System.Linq;
using Calamari.Azure.Accounts;
using Calamari.Deployment;
using Calamari.HealthChecks;
using Calamari.Integration.Certificates;
using Calamari.Integration.Processes;
using Microsoft.Azure.Management.WebSites;

namespace Calamari.Azure.HealthChecks
{
    public class WebAppHealthChecker : IDoesDeploymentTargetTypeHealthChecks
    {
        private readonly ILog log;
        private readonly ICertificateStore certificateStore;

        public WebAppHealthChecker(ILog log, ICertificateStore certificateStore)
        {
            this.log = log;
            this.certificateStore = certificateStore;
        }

        public bool HandlesDeploymentTargetTypeName(string deploymentTargetTypeName)
        {
            return deploymentTargetTypeName == "AzureWebApp";
        }

        public int ExecuteHealthCheck(CalamariVariableDictionary variables)
        {
            var account = AccountFactory.Create(variables);

            var resourceGroupName = variables.Get(SpecialVariables.Action.Azure.ResourceGroupName);
            var webAppName = variables.Get(SpecialVariables.Action.Azure.WebAppName);

            ConfirmWebAppExists(account, resourceGroupName, webAppName);
            
            return 0;
        }

        void ConfirmWebAppExists(AzureServicePrincipalAccount servicePrincipalAccount, string resourceGroupName, string siteAndSlotName)
        {
            using (var webSiteClient = servicePrincipalAccount.CreateWebSiteManagementClient())
            {
                var matchingSite = webSiteClient.WebApps
                    .ListByResourceGroup(resourceGroupName, true)
                    .ToList()
                    .FirstOrDefault(x => string.Equals(x.Name, siteAndSlotName, StringComparison.CurrentCultureIgnoreCase));
                if (matchingSite == null)
                    throw new Exception($"Could not find site {siteAndSlotName} in resource group {resourceGroupName}, using Service Principal with subscription {servicePrincipalAccount.SubscriptionNumber}");
            }
        }
    }
}