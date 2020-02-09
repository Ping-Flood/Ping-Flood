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
    isVolunteer:boolean;
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
    seekerUserId?:number;
    volunteerUserId?:number;
    isConfirmationRequired:boolean;
    expiration:Date;
    date:Date;
    match?:Match;
    seeker?:User;
    volunteer?:User;
}

