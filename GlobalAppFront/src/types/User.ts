export interface User {
    uuid: string;
    userName: string;
    password: string;
    firstName: string;
    lastName: string;
    fullName: string;
    email: string;
    card: string;
    pin: number;
    image: string | null;
    isActive: boolean;
    createdDate: string;
}

export interface CreateUser {
    userName: string;
    password: string;
    firstName: string;
    lastName: string;
    email: string;
    card: string;
    pin: number | null;
}

export interface UserGlobalPerms{
    canAccessGloba:boolean,
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