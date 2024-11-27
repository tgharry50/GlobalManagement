export interface UserName{
    uuid: string,
    fullName: string
}
export interface UserPerm{
    uuid: string,
    fullName: string,
    appname:string,
    appuuid:string,
    role:string,
    roleuuid:string,
}
export interface AppPerms{
    uuid:string,
    roleName:string,
    appName:string,
    appUuid:string,
}
export interface GlobalAppPerms extends AppPerms{
    canAccessGlobal:boolean,
    canBeEdited:boolean,
    // User
    createUser:boolean,
    updateUser:boolean,
    canDeleteUser:boolean,
    // Roles
    createCustomRole:boolean,
    updateCustomRole:boolean,
    deleteCustomRole:boolean,
    // Groups
    canCreateGroup:boolean,
    canDeleteGroup:boolean,
    canUpdateGroup:boolean
}
export interface ControlReportPerms extends AppPerms{
    canBeEdited: boolean,
    hasAllPrivelage: boolean,
    canUseApp: boolean,
    // Reference
    canCreateReference: boolean,
    canDeleteReference: boolean,
    canUpdateReference: boolean,
    canReadReference:boolean,
    // Interventions
    canCreateIntervention: boolean,
    canDeleteIntervention: boolean,
    canReadIntervention: boolean,
    canUpdateInterevention: boolean,
    // Tasks
    canCreateTask: boolean,
    canDeleteTask: boolean,
    canUpdateTask:boolean,
    canReadTask:boolean,
    // ECR
    canCreateEcr: boolean,
    canRemoveEcr:boolean,
    canUpdateEcr:boolean,
    canReadEcr:boolean,
    // Deviation
    canCreateDeviation:boolean,
    canReadDeviation: boolean,
    canUpdateDeviation: boolean,
    canDeleteDeviation: boolean,
}