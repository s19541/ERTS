import { Container, Row, Col, Table, Image } from "react-bootstrap";
import { Player } from "../../../../services/GeneratedClient";

import { useHistory } from "react-router";

function PlayerList(props: {
    players: Player[] | undefined;
}) {
    var players = props.players;
    return (
        <Container>
            <h1>Roster</h1>
            {players?.map((player, i) => (
                <Row>
                    <Col md="auto">
                        <Image src={`/images/flags/${player?.nationality}.png`}
                            width={25}
                            height={25} />
                    </Col>
                    <Col md="auto">
                        {player?.nick}
                    </Col>
                    <Col md="auto">
                        {player?.firstName} {player?.lastName}
                    </Col>
                </Row>
            ))}
        </Container>
    );
}

export default PlayerList;
