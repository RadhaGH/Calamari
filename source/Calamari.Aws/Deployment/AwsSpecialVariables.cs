﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calamari.Aws.Deployment
{
    public static class AwsSpecialVariables
    {
        public static class S3
        {
            public const string FileSelections = "Octopus.Action.Aws.S3.FileSelections";
            public const string PackageOptions = "Octopus.Action.Aws.S3.PackageOptions";
        }

        public static class CloudFormation
        {
            public const string Action = "Octopus.Action.Aws.CloudFormationAction";
            public const string StackName = "Octopus.Action.Aws.CloudFormationStackName";
            public const string Template = "Octopus.Action.Aws.CloudFormationTemplate";
            public const string TemplateParameters = "Octopus.Action.Aws.CloudFormationTemplateParameters";
            public const string TemplateParametersRaw = "Octopus.Action.Aws.CloudFormationTemplateParametersRaw";
            public const string RoleArn = "Octopus.Action.Aws.CloudFormation.RoleArn";
            
            public static class Changesets
            {
                public const string Feature = "Octopus.Features.CloudFormation.ChangeSet.Feature";
                public const string Name = "Octopus.Action.Aws.CloudFormation.ChangeSet.Name";
                public const string Mode = "Octopus.Action.Aws.CloudFormation.ChangeSet.Mode";
                public const string Generate = "Octopus.Action.Aws.CloudFormation.ChangeSet.GenerateName";
                public const string Arn = "Octopus.Action.Aws.CloudFormation.ChangeSet.Arn";
            }
        }
    }
}
