import { Button, Container } from "react-bootstrap";
import Header from "../../components/header/Header";
import './Home.css'

export default function Home() {
    return (
        <>
            <Header />
            <main className="d-none d-md-flex home-main">
                <div className="sidebar border border-right" style={{maxWidth: "335px", minWidth: "335px"}}>
                    <div className="text-center my-3 sidebar-header">
                        <span>Открытые комнаты</span>
                    </div>
                    <div className="sidebar-content rooms overflow-y-auto">
                    </div>
                </div>
                <Container className="w-100 overflow-hidden">
                    <div className="w-100">
                        <Button className="rounded-5 mx-auto d-block my-5 px-4 py-2">Создать комнату</Button>
                    </div>

                    <div>
                        <span className="d-block">Самые популярные</span>
                        <div className="d-flex my-4 overflow-x-scroll pb-3" style={{maxWidth: "100%"}}>
                            <div style={{ minWidth: "212px", maxWidth: "212px"}} className="me-2">
                                <div className="movie-card-image w-100" style={{minHeight: "307px", maxHeight: "307px", backgroundImage: "url('https://www.kino-teatr.ru/movie/poster/138188/112943.jpg')", backgroundSize: "cover"}}/>
                                <span className="d-block text-center mt-2">Главный Герой</span>
                            </div>
                        </div>
                    </div>
                </Container>
            </main>
        </>
    )
}