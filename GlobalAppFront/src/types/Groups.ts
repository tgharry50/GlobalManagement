export interface Group{
    uuid: string,
    name: string,
    description: string,
    hala: string,
    section: string,
    type: string,
    isActive: boolean
}

export interface Group_Add{
    Name: string,
    Description: string,
    Hala: string,
    Section: string,
}

export interface GroupMember{
    uuid: string,
    groupname: string,
    groupuuid: string,
    username: string,
    userguid: string,
    role: string,
    roleguid: string,
    isActive: boolean
}
export interface GroupMemberAdd{
    groupuuid: string,
    userguid: string,
    roleguid: string,
}

export interface GroupMemberSelectRole{
    uuid: string,
    roleName: string
}