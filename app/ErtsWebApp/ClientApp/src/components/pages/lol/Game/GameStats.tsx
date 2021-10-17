import React from "react";
import { Container } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import "../../../../css/myStyle.css";
import { GameClient, LolGameFullStatsDto } from "../../../../services/GeneratedClient";
import {
    IActionParameters,
    SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";
import GameInfo from "./GameInfo";

interface IProps { }

interface IPassedProps {
    gameId: string;
}

interface IState {
    gameId: number;
    game: LolGameFullStatsDto | null;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class GameStats extends React.Component<IJoinedProps, IState> {
    constructor(props: IJoinedProps) {
        super(props);

        this.state = {
            gameId: Number(props.match.params.gameId),
            game: null,
        };
    }

    componentDidMount() {
        let actionParameters: IActionParameters<LolGameFullStatsDto | null> = {
            action: () => new GameClient().getLolGameStats(this.state.gameId),
            onSuccess: (response) => {
                this.setState({
                    game: response,
                });
            },
        };

        SendActionWithResponse(actionParameters);
    }

    render() {
        return (
            <Container
                style={{
                    paddingBottom: "10vh",
                    paddingTop: "5vh",
                }}
            >
                <GameInfo game={this.state.game} />
            </Container>
        );
    }
}
export default withRouter(GameStats);
