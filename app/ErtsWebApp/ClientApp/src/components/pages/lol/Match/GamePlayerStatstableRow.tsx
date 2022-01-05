import { Col, Row, Image } from "react-bootstrap";
import { LolGamePlayerShortStatsDto } from "../../../../services/GeneratedClient";

interface IProps {
	playerStats: LolGamePlayerShortStatsDto;
}

const GamePlayerStatsTableRow: React.FunctionComponent<IProps> = (props) => {
	const playerStats = props.playerStats;

	return (
		<tr>
			<td
				style={{
					verticalAlign: "middle",
					width: "13vh",
				}}
			>
				<Row>
					<Col md="5" style={{ textAlign: "right" }}>
						<Image
							src={playerStats?.championImageUrl}
							className=""
							width={60}
							height={60}
						/>
					</Col>
					<Col md="auto" style={{ textAlign: "center" }}>
						<Row>
							<Col md="auto" style={{ textAlign: "center" }}>
								<Image
									src={playerStats?.spell1ImageUrl}
									className=""
									width={29}
									height={29}
								/>
							</Col>
						</Row>

						<Row>
							<Col
								md="auto"
								style={{ textAlign: "center", verticalAlign: "middle" }}
							>
								<Image
									src={playerStats?.spell2ImageUrl}
									className=""
									width={29}
									height={29}
								/>
							</Col>
						</Row>
					</Col>
				</Row>
			</td>
			<td
				style={{
					textAlign: "center",
					verticalAlign: "middle",
				}}
			>
				{playerStats.playerNick}
			</td>
			<td
				style={{
					textAlign: "center",
					verticalAlign: "middle",
				}}
			>
				{playerStats.kills}/{playerStats.deaths}/{playerStats.assists}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.cs}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.goldEarned}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "left",
					width: "31vh",
				}}
			>
				{playerStats.itemImages?.map((itemImage, i) => (
					<Image src={itemImage} className="" width={35} height={35} />
				))}
			</td>
		</tr>
	);
}
export default GamePlayerStatsTableRow;
