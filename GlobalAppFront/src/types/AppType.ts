export interface AppModel{ //Defines app model
    uuid: string;
    name: string;
    description: string;
    address: string;
    isactive: boolean;
    createdat: string;
}
export interface CreateApp{ // DTO for app
    name: string;
    description: string;
    address: string;
}
export interface Owner{ // DTO for getting owners
    uuid: string;
    appuuid: string;
    fullname: string;
}
export interface Options{ // DTO for options, not in usde
    uuid: string;
    appuuid: string;
}
export interface CreateOwner{ // DTO for creating owner of the app
    appuuid: string,
    useruuid: string
}
export interface UserList{ // User list for selecting an owner of the app
    uuid: string,
    fullName: string
}