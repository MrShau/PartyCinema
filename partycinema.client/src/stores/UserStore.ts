import { makeAutoObservable } from "mobx";

export type UserType = {
    login : string;
    id : number;
    imagePath : string;
}

export default class UserStore
{
    isAuth : boolean = false;
    user : UserType | null = null;

    constructor() {
        makeAutoObservable(this);
    }

    public setIsAuth(value: boolean) {
        this.isAuth = value;
    }

    public setUser(user : UserType | null) {
        this.user = user;
    }
}
