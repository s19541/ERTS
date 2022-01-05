import { Row, Col, Image } from "react-bootstrap";

interface IProps {
    name: string;
    blueTeamBoolean: boolean | undefined;
    redTeamBoolean: boolean | undefined;
}

const GameTeamExcludingStats: React.FunctionComponent<IProps> = (props) => {
    var name = props.name;
    var blueTeamBoolean = props.blueTeamBoolean;
    var redTeamBoolean = props.redTeamBoolean;
    return (
        <Row>
            <Col style={{ textAlign: "right" }}>
                <h4>
                    {blueTeamBoolean ?
                        <Image
                            src="/images/accept.png"
                            width={29}
                            height={29}
                            alt="cloudDrake"
                        />
                        :
                        <Image
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
                        <Image
                            src="/images/accept.png"
                            width={29}
                            height={29}
                            alt="true"
                        />
                        :
                        <Image
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