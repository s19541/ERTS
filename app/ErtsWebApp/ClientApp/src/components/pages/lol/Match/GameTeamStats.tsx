import { Container, Row, Col, Image } from "react-bootstrap";
import { LolGameTeamShortStatsDto } from "../../../../services/GeneratedClient";
import { useTranslation } from "react-i18next";

interface IProps {
	teamStats: LolGameTeamShortStatsDto | undefined;
}

const GameTeamStats: React.FunctionComponent<IProps> = (props) => {
	const teamStats = props.teamStats;
	const { t } = useTranslation();

	return (
		<Container>
			<Row>
				<Col md="auto">{t("match.gold")}: {teamStats?.goldEarned}</Col>
				<Col md="auto">
					{t("match.dragons")}:
					{[...Array(teamStats?.oceanDrakeKilled)].map((x, i) => (
						<Image
							src="/images/lol/ocean-drake-icon.png"
							width={29}
							height={29}
							alt="oceanDrake"
						/>
					))}
					{[...Array(teamStats?.infernalDrakeKilled)].map((x, i) => (
						<Image
							src="/images/lol/infernal-drake-icon.png"
							width={29}
							height={29}
							alt="infernalDrake"
						/>
					))}
					{[...Array(teamStats?.mountainDrakeKilled)].map((x, i) => (
						<Image
							src="/images/lol/mountain-drake-icon.png"
							width={29}
							height={29}
							alt="mountainDrake"
						/>
					))}
					{[...Array(teamStats?.cloudDrakeKilled)].map((x, i) => (
						<Image
							src="/images/lol/cloud-drake-icon.png"
							width={29}
							height={29}
							alt="cloudDrake"
						/>
					))}
				</Col>
				<Col>
					<Image
						src="/images/lol/elder-drake-icon.png"
						width={29}
						height={29}
						alt="elderDrake"
					/>
					:{teamStats?.elderDrakeKilled}
				</Col>
				<Col>
					<Image
						src="/images/lol/herald-icon.png"
						width={29}
						height={29}
						alt="herald"
					/>
					:{teamStats?.heraldKilled}
				</Col>
				<Col>
					<Image
						src="/images/lol/baron-icon.png"
						width={29}
						height={29}
						alt="baron"
					/>
					:{teamStats?.baronKilled}
				</Col>
				<Col>
					<Image
						src="/images/lol/tower-icon.png"
						width={29}
						height={29}
						alt="tower"
					/>
					:{teamStats?.turretDestroyed}
				</Col>
				<Col>
					<Image
						src="/images/lol/inhibitor-icon.png"
						width={29}
						height={29}
						alt="inhibitor"
					/>
					:{teamStats?.inhibitorDestroyed}
				</Col>
				<Col md="auto">
					{t("match.bans")}:
					<Image
						src={teamStats?.ban1ImageUrl}
						className=""
						width={29}
						height={29}
					/>
					<Image
						src={teamStats?.ban2ImageUrl}
						className=""
						width={29}
						height={29}
					/>
					<Image
						src={teamStats?.ban3ImageUrl}
						className=""
						width={29}
						height={29}
					/>
					<Image
						src={teamStats?.ban4ImageUrl}
						className=""
						width={29}
						height={29}
					/>
					<Image
						src={teamStats?.ban5ImageUrl}
						className=""
						width={29}
						height={29}
					/>
				</Col>
			</Row>
		</Container>
	);
}

export default GameTeamStats;
