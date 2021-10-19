import { Row, Col } from "react-bootstrap";
function GameTeamExcludingStats(props: { name: string, blueTeamBoolean: boolean | undefined, redTeamBoolean: boolean | undefined }) {
    var name = props.name;
    var blueTeamBoolean = props.blueTeamBoolean;
    var redTeamBoolean = props.redTeamBoolean;
    return (
        <Row>
            <Col style={{ textAlign: "right" }}>
                <h4>
                    {blueTeamBoolean ?
                        <img
                            src="/images/accept.png"
                            width={29}
                            height={29}
                            alt="cloudDrake"
                        />
                        :
                        <img
                            src="/images/xmark.png"
                            width={29}
                            height={29}
                            alt="cloudDrake"
                        />}
                </h4>
            </Col>
            <Col style={{ textAlign: "center" }}><h4>{name}</h4></Col>
            <Col style={{ textAlign: "left" }}>
                <h4>
                    {redTeamBoolean ?
                        <img
                            src="/images/accept.png"
                            width={29}
                            height={29}
                            alt="true"
                        />
                        :
                        <img
                            src="/images/xmark.png"
                            width={29}
                            height={29}
                            alt="false"
                        />}
                </h4>
            </Col>
        </Row>
    );
}

export default GameTeamExcludingStats;