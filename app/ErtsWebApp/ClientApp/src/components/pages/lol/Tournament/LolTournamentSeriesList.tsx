import React from "react";
import { Container } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import "../../../../css/myStyle.css";
import {
	SeriesClient,
	SeriesShortDto,
} from "../../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";
import LolSeriesListTable from "../LolSeriesListTable";
import LolTournamentNav from "./LolTournamentNav";

interface IProps {}

interface IPassedProps {
	tournamentId: string;
}

interface IState {
	tournamentId: number;
	seriesList: SeriesShortDto[] | null;
	key: string;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class LolTournamentSeries extends React.Component<IJoinedProps, IState> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			tournamentId: Number(props.match.params.tournamentId),
			seriesList: null,
			key: "series",
		};
	}

	componentDidMount() {
		let actionParameters: IActionParameters<SeriesShortDto[] | null> = {
			action: () => new SeriesClient().getSeriesShort(this.state.tournamentId),
			onSuccess: (response) => {
				this.setState({
					seriesList: response,
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
				<LolSeriesListTable seriesList={this.state.seriesList} />
			</Container>
		);
	}
}
export default withRouter(LolTournamentSeries);
