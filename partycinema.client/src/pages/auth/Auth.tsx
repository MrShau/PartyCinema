import { Button, ButtonGroup, Container, Form } from "react-bootstrap";
import { useState } from "react";
import { Link } from "react-router-dom";

import './Auth.css'
import UserSvg from "../../svgs/UserSvg";
import PasswordSvg from "../../svgs/PasswordSvg";
import UserApi from "../../api/UserApi";

export default function Auth() {

    const [tab, setTab] = useState<string>('login');

    const [login, setLogin] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const [repeatPassword, setRepeatPassword] = useState<string>('');
    const [error, setError] = useState<string>('');

    const onClickContinue = async () => {
        if (login.length > 50)
            return setError('Максимальная длина логина - 50');
        if (login.length < 3)
            return setError('Минимальная длина логина - 3');
        if (password.length > 100)
            return setError('Слишком длинный пароль !')
        if (password.length < 8)
            return setError('Минимальная длина пароля - 8');

        if (tab == 'registration' && repeatPassword != password)
            return setError('Пароли не совпадают !')

        setError('');
        setError(tab == 'registration' ? await UserApi.signup(login, password) : await UserApi.signin(login, password));
    }

    return (
        <Container className="vh-100">
            <main className="d-flex align-items-center justify-content-center h-100">
                <div className="auth-block col-xxl-3 col-xl-4 col-lg-5 col-md-7 col-sm-8 col-12">
                    <div className="mb-5">
                        <ButtonGroup className="col-12 d-flex justify-content-between">
                            <Button
                                variant={`${tab == 'login' ? 'primary' : 'outline-primary'}`}
                                onClick={() => tab == 'login' ? 0 : setTab('login')}
                                className="col-6 py-2"
                            >Войти</Button>
                            <Button
                                variant={`${tab == 'registration' ? 'primary' : 'outline-primary'}`}
                                onClick={() => tab == 'registration' ? 0 : setTab('registration')}
                                className="col-6"
                            >Регистрация</Button>
                        </ButtonGroup>
                    </div>
                    <Form className="form-auth">
                        <div>
                            <div className="input-icon px-3 py-3"><UserSvg /></div>
                            <Form.Control
                                type="name"
                                className="py-3 ps-5 pe-3"
                                placeholder='Логин'
                                readOnly
                                value={login}
                                autoComplete="off"
                                onFocus={e => e.target.removeAttribute('readOnly')}
                                onChange={e => setLogin(e.target.value)}
                            />
                        </div>
                        <div>
                            <div className="input-icon px-3 py-3"><PasswordSvg /></div>
                            <Form.Control
                                type="password"
                                className={`py-3 ps-5 pe-3 ${tab == 'registration' ? 'rounded-0' : ''}`}
                                placeholder="Пароль"
                                readOnly
                                onFocus={e => e.target.removeAttribute('readOnly')}
                                autoComplete="off"
                                onChange={e => setPassword(e.target.value)}
                            />
                        </div>

                        {
                            tab == "registration" ?
                                <div>
                                    <div className="input-icon px-3 py-3"><PasswordSvg /></div>
                                    <Form.Control
                                        type="password"
                                        className="py-3 ps-5 pe-3"
                                        placeholder="Повторите пароль"
                                        readOnly
                                        autoComplete="off"
                                        onFocus={e => e.target.removeAttribute('readOnly')}
                                        onChange={e => setRepeatPassword(e.target.value)}
                                    />
                                </div>
                                : <></>
                        }

                        <Link to="/auth" className="d-block my-4 link">Забыли пароль ?</Link>
                        <Button variant="outline-primary" className="rounded-0 col-12 my-2 py-2" onClick={onClickContinue}>Продолжить</Button>
                    </Form>
                    <div className="text-danger small mt-3 text-center">{error}</div>
                </div>
            </main>
        </Container>
    )
}