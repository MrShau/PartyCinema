import axios from "axios";
import { API_HOST } from "../consts";
import { UserType } from "../stores/UserStore";

class UserApi 
{
    private getBearer() : string {
        return `Bearer ${localStorage.getItem('token')}`;
    }

    public async signup(login: string, password: string) : Promise<string> {
        let result = '';

        try {
            await axios.post(`${API_HOST}/api/user/signup`, {login, password})
            .then(res => {
                if (res.data.token == null)
                    return;
                localStorage.setItem('token', res.data.token);
                window.location.href = '/';
            })
            .catch(res => result = res.response.data.message);
        }
        catch (ex) {
            console.log(ex);
        }

        return result;
    } 

    public async signin(login: string, password: string) : Promise<string> {
        let result = '';

        try {
            await axios.post(`${API_HOST}/api/user/signin`, {login, password})
            .then(res => {
                if (res.data.token == null)
                    return;
                localStorage.setItem('token', res.data.token);
                window.location.href = '/';
            })
            .catch(res => result = res.response.data.message);
        }
        catch (ex) {
            console.log(ex);
        }

        return result;
    } 

    public async auth() : Promise<UserType | null> {
        let result : UserType | null = null;
        try {
            await axios.get(`${API_HOST}/api/user/auth`, {headers: {Authorization: this.getBearer()}})
                .then(res => {
                    result = res.data;
                })
                .catch(() => {
                    localStorage.removeItem('token');
                });
        }
        catch (ex) {
            console.log(ex);
        }
        
        return result;
    }

    public async logout() {
        if (localStorage.getItem('token') != null) {
            localStorage.removeItem('token');
            window.location.reload();
        }
    }
}

export default new UserApi();