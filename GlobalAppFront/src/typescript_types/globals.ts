export type UserData = {
    uuid: string,
    username: string,
    firstname: string,
    lastname: string,
    email: string,
    card: string,
    pin: number
}
export type UserPermission = {
    // General
    CanAccessGlobal: boolean,
    CanBeEdited: boolean,
    // Users
    CreateUser: boolean,
    UpdateUser: boolean,
    DeleteUser: boolean,
    // Roles
    CreateCustomRole: boolean,
    UpdateCustomRole: boolean,
    DeleteCustomRole: boolean,
    // Groups
    CanCreateGroup: boolean,
    CanDeleteGroup: boolean,
    CanUpdateGroup: boolean
}