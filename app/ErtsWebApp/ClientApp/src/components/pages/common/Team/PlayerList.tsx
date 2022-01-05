import { Container, Row, Col, Table, Image } from "react-bootstrap";
import { Player } from "../../../../services/GeneratedClient";
import { useTranslation } from "react-i18next";

interface IProps {
    players: Player[] | undefined;
}

const PlayerList: React.FunctionComponent<IProps> = (props) => {
    var players = props.players;
    const { t } = useTranslation();

    return (
        <Container>
            <h1>{t("team.roster")}</h1>
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
