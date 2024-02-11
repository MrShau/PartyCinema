import { useContext} from "react";
import { Button, Container, Dropdown, Form, Navbar } from "react-bootstrap";
import { Link } from "react-router-dom";
import { Context } from "../../main";
import { API_HOST } from "../../consts";
import UserSvg from "../../svgs/UserSvg";
import LogoutSvg from "../../svgs/LogoutSvg";
import './Header.css'

export default function Header() {

    const stores = useContext(Context);

    return (
        <>
            <Navbar bg="dark" expand="md" className="position-relative border-bottom">
                <Container>
                <Navbar.Brand className="d-md-none"><Link to="/" className="text-primary logo">PartyCinema</Link></Navbar.Brand>
                    <div style={{width: "170px", height: "10px"}} className="d-none d-md-block"></div>
                    <Navbar.Brand className="brand position-absolute d-none d-md-block"><Link to="/" className="text-primary logo">PartyCinema</Link></Navbar.Brand>
                    <Navbar.Toggle aria-controls="main-navbar-nav" />
                    <Navbar.Collapse id="main-navbar-nav">
                        <Form className="col-12 col-sm-10 col-md-7 col-lg-7 col-xl-5 mx-auto my-3 my-md-0">
                            <Form.Control
                                className="px-4 py-2 rounded-5"
                                type="search"
                                placeholder="Введите название фильма..."
                            />
                        </Form>
                        <div className="text-center text-md-end my-3 my-md-0">
                            {
                                stores?.user.isAuth ?
                                    <>
                                        <Dropdown drop="start" className="">
                                            <Dropdown.Toggle variant="outline-primary" id="dropdown-basic" className="bg-transparent border-0 circle p-0">
                                                <img src={`${API_HOST}/${stores?.user.user?.imagePath}`} className="circle" style={{ width: '52px', height: "52px", objectFit: "cover" }} />
                                            </Dropdown.Toggle>

                                            <Dropdown.Menu variant="dark" className="bg-secondary shadow">
                                                <Dropdown.ItemText className="text-center text-white">#{stores?.user.user?.login}</Dropdown.ItemText>
                                                <Dropdown.Divider></Dropdown.Divider>
                                                <Dropdown.Item href="/account">
                                                    <div className="d-flex align-items-center">
                                                        <div className="user_svg">
                                                            <UserSvg />
                                                        </div>
                                                        <div className="px-3 py-1">
                                                            Личный кабинет
                                                        </div>
                                                    </div>
                                                </Dropdown.Item>

                                                <Dropdown.Divider></Dropdown.Divider>
                                                <Dropdown.Item>
                                                    <div className="d-flex align-items-center">
                                                        <div>
                                                            <LogoutSvg />
                                                        </div>
                                                        <div className="px-3 py-1">
                                                            Выйти
                                                        </div>
                                                    </div>
                                                </Dropdown.Item>
                                            </Dropdown.Menu>
                                        </Dropdown>
                                    </>
                                    :
                                    <Link to="/auth"><Button variant="outline-primary" className="px-5 py-2 rounded-5">Войти</Button></Link>
                            }
                        </div>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
        </>
    )
}