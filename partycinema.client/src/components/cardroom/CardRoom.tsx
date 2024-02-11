import { Link } from "react-router-dom";

type PropsType = {
    imagePath: string, 
    title: string,
    viewers: number, 
    movieId: number,
    className?: string | null,
    key?: string | null
}

export default function CardRoom(props: PropsType) {
    return (
            <div className={`d-flex border px-1 py-1 ms-2 me-3 rounded-3 ${props.className}`} style={{maxHeight: "70px", height: "70px"}} key={props.key}>
                <div style={{maxHeight: "62px", height: "62px", width: "62px", maxWidth: "62px"}}>
                    <img src={props.imagePath} className="h-100 w-100 object-fit-cover rounded-1"/>
                </div>
                <div className="ps-2 d-flex align-items-center">
                    <div>
                        <span className="d-block small">{props.title}</span>
                        <span className="d-block text-secondary" style={{fontSize: "12px"}}>зрителей: {props.viewers}</span>
                        <Link to={`/createroom?movieId=${props.movieId}`} className="d-block link" style={{fontSize: "12px"}}>Клонировать</Link>

                    </div>
                </div>
            </div>
    )
}