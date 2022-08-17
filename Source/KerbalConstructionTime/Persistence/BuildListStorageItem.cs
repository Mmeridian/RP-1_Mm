﻿using System;
using System.Collections.Generic;
using RP0.DataTypes;

namespace KerbalConstructionTime
{
    public class BuildListStorageItem
    {
        [Persistent]
        string shipName, shipID;
        [Persistent]
        double progress, effectiveCost, buildPoints, integrationPoints;
        [Persistent]
        string launchSite, flag;
        [Persistent]
        bool cannotEarnScience;
        [Persistent]
        float cost = 0, integrationCost;
        [Persistent]
        float mass = 0, emptyMass = 0, kscDistance = 0;
        [Persistent]
        int numStageParts = 0, numStages = 0;
        [Persistent]
        double stagePartCost = 0;
        [Persistent]
        int rushBuildClicks = 0;
        [Persistent]
        int EditorFacility = 0, LaunchPadID = -1;
        [Persistent]
        List<string> desiredManifest = new List<string>();
        [Persistent]
        string KCTPersistentID;
        [Persistent]
        EditorFacility FacilityBuiltIn;
        [Persistent]
        bool humanRated;
        [Persistent]
        PersistentDictionaryValueTypes<string, double> resourceAmounts = new PersistentDictionaryValueTypes<string, double>();
        [Persistent]
        PersistentHashSetValueType<string> globalTags = new PersistentHashSetValueType<string>();
        [Persistent]
        BuildListVessel.ClampsState clampState = BuildListVessel.ClampsState.Untested;

        public BuildListVessel ToBuildListVessel()
        {
            var ret = new BuildListVessel(shipName, launchSite, effectiveCost, buildPoints, integrationPoints, flag, cost, integrationCost, EditorFacility, humanRated)
            {
                Progress = progress,
                Id = new Guid(shipID),
                CannotEarnScience = cannotEarnScience,
                TotalMass = mass,
                EmptyMass = emptyMass,
                NumStageParts = numStageParts,
                NumStages = numStages,
                StagePartCost = stagePartCost,
                DistanceFromKSC = kscDistance,
                RushBuildClicks = rushBuildClicks,
                LaunchSiteIndex = LaunchPadID,
                DesiredManifest = desiredManifest,
                KCTPersistentID = KCTPersistentID,
                FacilityBuiltIn = FacilityBuiltIn,
                resourceAmounts = resourceAmounts,
                globalTags = globalTags,
                hasClamps = clampState
            };
            return ret;
        }

        public BuildListStorageItem FromBuildListVessel(BuildListVessel blv)
        {
            progress = blv.Progress;
            effectiveCost = blv.EffectiveCost;
            buildPoints = blv.BuildPoints;
            integrationPoints = blv.IntegrationPoints;
            launchSite = blv.LaunchSite;
            flag = blv.Flag;
            shipName = blv.ShipName;
            shipID = blv.Id.ToString();
            cannotEarnScience = blv.CannotEarnScience;
            cost = blv.Cost;
            integrationCost = blv.IntegrationCost;
            rushBuildClicks = blv.RushBuildClicks;
            mass = blv.TotalMass;
            numStageParts = blv.NumStageParts;
            numStages = blv.NumStages;
            stagePartCost = blv.StagePartCost;
            kscDistance = blv.DistanceFromKSC;
            EditorFacility = (int)blv.GetEditorFacility();
            LaunchPadID = blv.LaunchSiteIndex;
            desiredManifest = blv.DesiredManifest;
            KCTPersistentID = blv.KCTPersistentID;
            FacilityBuiltIn = blv.FacilityBuiltIn;
            humanRated = blv.IsHumanRated;
            resourceAmounts = blv.resourceAmounts;
            globalTags = blv.globalTags;
            return this;
        }
    }
}

/*
    KerbalConstructionTime (c) by Michael Marvin, Zachary Eck

    KerbalConstructionTime is licensed under a
    Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License.

    You should have received a copy of the license along with this
    work. If not, see <http://creativecommons.org/licenses/by-nc-sa/4.0/>.
*/
