export class User {
    id:string;
    name:string;
    email:string;
    password:string;
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

