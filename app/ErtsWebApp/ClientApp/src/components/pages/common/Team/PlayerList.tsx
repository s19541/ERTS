import { Container, Row, Col, Table, Image } from "react-bootstrap";
import { Player } from "../../../../services/GeneratedClient";

import { useHistory } from "react-router";

function LolMatchListTable(props: {
    players: Player[] | undefined;
}) {
    var players = props.players;
    return (
        <Container>
            <Table striped bordered hover variant="dark">
                <thead>
                    <tr>
                        <th style={{ textAlign: "center" }}>Nationality</th>
                        <th style={{ textAlign: "center" }}>Nick</th>
                        <th style={{ textAlign: "center" }}>Name</th>
                    </tr>
                </thead>
                <tbody>
                    {players?.map((player, i) => (
                        <tr>
                            <td>
                                <Image src={`/images/flags/${player?.nationality}.png`}
                                    width={50}
                                    height={50} />
                                {player?.nationality}
                            </td>
                            <td>
                                {player.nick}
                            </td>
                            <td>
                                {player.firstName} {player.lastName}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}

export default LolMatchListTable;
