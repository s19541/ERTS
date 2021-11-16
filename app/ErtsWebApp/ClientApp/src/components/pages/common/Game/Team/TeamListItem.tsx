import { Card, CardGroup, Col, Container, Image, Row } from "react-bootstrap";
import { useHistory } from "react-router";
import { TeamImageDto } from "../../../../../services/GeneratedClient";

function TeamListItem(props: { gameType: string; teamImageDto: TeamImageDto }) {
    let history = useHistory();

    const redirectToPage = (page: string) => {
        history.push(page);
    }

    var gameType = props.gameType;
    var color = 'transparent'
    var teamImageDto = props.teamImageDto;
    return (

        <Card className="align-items-center" bg={color} border='white' style={{ width: '10rem', color: "white", textAlign: "center" }}
            onClick={() => redirectToPage(`/${gameType}/team/${teamImageDto.id}`)}

        >
            <Image src={teamImageDto.imageUrl} rounded
                width={150}
                height={150} />

            <h6>{teamImageDto.name}</h6>
        </Card>

    );
}

export default TeamListItem;