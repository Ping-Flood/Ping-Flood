export class User {
    id?:number;
    firstname:string;
    lastname:string;
    email:string;
    password:string;
    address:string;
    city:string;
    sectorTypeId:number;
    matches?:Match[];
    isSeeker:boolean;
    isVolonteer:boolean;
    emailAlert:boolean;
    smsAlert:boolean;
    phone:number;
}

export class Match{
    id?:number;
    demandsId:number;
    seekerUsersId:number;
    volunteerUsersId:number;
    demandStatusId:number;
    date:Date;
}

export class Demand{
    id:number;
    demandTypeId:number;
    demandType:DemandType;
    seekerUser:User;
    seekerUserId?:number;
    volonteerUser:User;
    volunteerUserId?:number;
    isConfirmationRequired:boolean;
    match?:Match;
    seeker?:User;
    volunteer?:User;
    expiration:Date|string;
    date:Date|string;
    commentaire:string;
}

export class DemandType{
    id:number;
    description:string;
}