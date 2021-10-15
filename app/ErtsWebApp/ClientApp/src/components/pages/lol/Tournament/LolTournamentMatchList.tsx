import React from "react";
import { Container } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import "../../../../css/myStyle.css";
import { MatchClient, MatchDto } from "../../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";
import LolMatchListTable from "../LolMatchListTable";
import LolTournamentNav from "./LolTournamentNav";

interface IProps { }

interface IPassedProps {
	tournamentId: string;
}

interface IState {
	tournamentId: number;
	matchList: MatchDto[] | null;
	key: string;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class LolTournamentMatchList extends React.Component<IJoinedProps, IState> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			tournamentId: Number(props.match.params.tournamentId),
			matchList: null,
			key: "matches",
		};
	}

	componentDidMount() {
		let actionParameters: IActionParameters<MatchDto[] | null> = {
			action: () => new MatchClient().getMatches(this.state.tournamentId),
			onSuccess: (response) => {
				this.setState({
					matchList: response,
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
				<LolTournamentNav activeKey={this.state.key} />
				<LolMatchListTable matchList={this.state.matchList} />
			</Container>
		);
	}
}
export default withRouter(LolTournamentMatchList);
