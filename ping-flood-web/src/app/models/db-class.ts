export class User {
    id?:number;
    firstname:string;
    lastname:string;
    email:string;
    password:string;
    address:string;
    city:string;
    secteurTypeId:number;
    offers?:Offer[];
    demands?:Demand[];
}

export class Offer{
    id:string;
    title:string;
    msg:string;
}

export class Demand{
    id:string;
    title:string;
    msg:string;
}

