﻿using System.ComponentModel.DataAnnotations;

namespace GlobalManagement.Controllers.PermissionsController.dto
{
    public class _GetControlReportPermissions
    {
        public Guid UUID { get; set; }
        public required string RoleName { get; set; }
        public required string AppName { get; set; }
        public required Guid AppUuid { get; set; }
        public bool CanBeEdited { get; set; }
        public bool HasAllPrivelage { get; set; }
        public bool CanUseApp { get; set; }
        // Reference
        public bool CanCreateReference { get; set; }
        public bool CanDeleteReference { get; set; }
        public bool CanUpdateReference { get; set; }
        public bool CanReadReference { get; set; }
        // Interventions 
        public bool CanCreateIntervention { get; set; }
        public bool CanDeleteIntervention { get; set; }
        public bool CanUpdateIntervention { get; set; }
        public bool CanReadIntervention { get; set; }
        // Tasks
        public bool CanCreateTask { get; set; }
        public bool CanDeleteTask { get; set; }
        public bool CanUpdateTask { get; set; }
        public bool CanReadTask { get; set; }
        // ECR
        public bool CanCreateEcr { get; set; }
        public bool CanDeleteEcr { get; set; }
        public bool CanUpdateEcr { get; set; }
        public bool CanReadEcr { get; set; }
        // Deviation
        public bool CanCreateDeviation { get; set; }
        public bool CanDeleteDeviation { get; set; }
        public bool CanUpdateDeviation { get; set; }
        public bool CanReadDeviation { get; set; }
    }
}